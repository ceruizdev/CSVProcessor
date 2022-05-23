import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { lastValueFrom, map, Observable, ReplaySubject } from 'rxjs';
import { CSVBody } from 'src/resources/models/CSVBody';
import { CSV } from 'src/resources/services/CSVService/csv.service';
import { requiredFileType } from 'src/resources/validators/fileValidator';
import { ToastrService } from 'ngx-toastr';
import { FileContentComponent } from 'src/app/shared/components/dialogs/file-content/file-content.component';
import { MatDialog } from '@angular/material/dialog';
import { ProcessedFile } from 'src/resources/models/procesedFile';

@Component({
  selector: 'app-csvprocessor',
  templateUrl: './csvprocessor.component.html',
  styleUrls: ['./csvprocessor.component.css']
})
export class CSVProcessorComponent implements OnInit {
  form!: FormGroup;
  processed: CSVBody[] = [];
  base64textString!: string;

  constructor(private fb: FormBuilder,
              private csvSevice: CSV,
              private toastr: ToastrService,
              private dialog: MatDialog) { }

  ngOnInit() {
    this.buildForm();
    this.getAllProcesedFiles();
  }

  buildForm(){
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      delimiter: [''],
      file: ['', [Validators.required, requiredFileType('csv')]],
    });
  }

  onFileChange(event: any) {
    var files = event.target.files;
    var file = files[0];
    if (files && file) {
      var reader = new FileReader();
      reader.onload = this._handleReaderLoaded.bind(this);
      reader.readAsBinaryString(file);
    }
  }

  _handleReaderLoaded(readerEvt: any) {
    var binaryString = readerEvt.target.result;
           this.base64textString = btoa(binaryString);
   }

  async getAllProcesedFiles(){
    const categories$ = this.csvSevice.getAll();
    this.processed = await lastValueFrom(categories$);
  }

  async createFile(){
    let newFile: CSVBody = {
      id:0,
      delimiter: this.delimiter && this.delimiter.value ? this.delimiter.value : ',',
      name: this.name?.value,
      fileAsBase64: this.base64textString 
    }
    var insertedRegistry$ = this.csvSevice.processFile(newFile); 
    const registry = await lastValueFrom(insertedRegistry$);
    this.form.reset();
    this.toastr.success('Registro ingresado exitosamente', 'hola', {timeOut: 100});
    this.processed.push(registry);
  }

  readBase64(file: any): Promise<any> {
    const reader = new FileReader();
    const future = new Promise((resolve, reject) => {
      reader.addEventListener('load', function () {
        resolve(reader.result);
      }, false);
      reader.addEventListener('error', function (event) {
        reject(event);
      }, false);
      reader.readAsDataURL(file);
    });
    return future;
  }

  async showDocument(CSV: CSVBody){
    const content$ = this.csvSevice.processString(CSV);
    var fileContent = await lastValueFrom(content$);
    this.openDialog(fileContent);
  }

  openDialog(content: ProcessedFile){
    let dialogRef = this.dialog.open(FileContentComponent, {
      height: '600px',
      width: '800px',
      data: content
    });
  }

  async deleteDocument(id:number){
    const content$ = this.csvSevice.deleteDocument(id);
    var fileContent = await lastValueFrom(content$);
    this.getAllProcesedFiles();
  }

  get file() {
    return this.form.get('file');
  }

  get name() {
    return this.form.get('name');
  }

  get delimiter() {
    return this.form.get('delimiter');
  }
}


