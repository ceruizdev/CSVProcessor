import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProcessedFile } from 'src/resources/models/procesedFile';
@Component({
  selector: 'app-file-content',
  templateUrl: './file-content.component.html',
  styleUrls: ['./file-content.component.css']
})
export class FileContentComponent implements OnInit {
  content!: ProcessedFile;
  constructor(public diaglogRef: MatDialogRef<FileContentComponent>,
              @Inject(MAT_DIALOG_DATA) public data:any ) { }

  full = true;
  splitted = false; 
  splittedWords = [];
  initial = 0;
  final = 20;        
  
  ngOnInit(): void {
    this.takeFromSplitted();
  }

  takeFromSplitted() {
    this.splittedWords = this.data.splittedContent ? this.data.splittedContent.slice(this.initial, this.final) : [];
  }

  addRegistries(){
    this.initial = this.final;
    this.final = this.final + 20 <= this.data.splittedContent.length ? this.final + 20 : this.data.splittedContent.length;
    let newValues = this.data.splittedContent.slice(this.initial, this.final);
    this.splittedWords = this.splittedWords.concat(newValues);
  }

  showSplittedContent(){
    this.full = false;
    this.splitted = true;
  }

  showFullContent(){
    this.full = true;
    this.splitted = false;
  }
}
