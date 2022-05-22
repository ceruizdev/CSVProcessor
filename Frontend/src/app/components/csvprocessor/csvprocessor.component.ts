import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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

  constructor(private fb: FormBuilder,
              private csvSevice: CSV) { }

  ngOnInit() {
    this.buildForm();
    this.getAllProcesedFiles();
  }

  buildForm(){
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      delimiter: ['', []],
      file: ['', [Validators.required, requiredFileType('csv')]],
    });
  }

  onFileChange(event:any){
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.patchValue({
        fileSource: file
      });

    }
  }

  getAllProcesedFiles(){
    this.csvSevice.getAll().subscribe(resp => {
      this.processed = resp;
    });
  }

  get file() {
    return this.form.get('file');
  }
}


