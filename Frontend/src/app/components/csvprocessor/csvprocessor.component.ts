import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Observable, ReplaySubject } from 'rxjs';
import { CSVBody } from 'src/resources/models/CSVBody';
import { CSV } from 'src/resources/services/CSVService/csv.service';
import { requiredFileType } from 'src/resources/validators/fileValidator';

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
              private csvSevice: CSV) { }

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

  getAllProcesedFiles(){
    this.csvSevice.getAll().subscribe(resp => {
      this.processed = resp;
    });
  }

  createFile(){
    let newFile: CSVBody = {
      id:0,
      delimiter: this.delimiter && this.delimiter.value ? this.delimiter.value : ',',
      name: this.name?.value,
      fileAsBase64: this.base64textString 
    }
    this.csvSevice.processFile(newFile).subscribe(resp => {
      console.log(resp);
      this.getAllProcesedFiles();
    });
  }

  private readBase64(file: any): Promise<any> {
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


