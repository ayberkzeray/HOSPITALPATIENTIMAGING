import { Component } from '@angular/core';
import xml2js from 'xml2js';
import * as converter from 'xml-js';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  xml: string;
  outputXml: any;
  inputXml: any;
  list: any = []
  constructor() {

  }

  ngOnInit() {
  }

  uploadedFile: any = '';
  getFilename(name) {
    return name.substring(0, name.lastIndexOf('.'));
  }
  getFileExtension(filename) {
    return (filename != '' && filename != undefined && filename != null) ? filename.split('.').pop() : '';
  }
  selectFile(event) {
    var file: File = event.target.files[0];
    this.fileType = this.getFileExtension(file.name);
    this.fileName = this.getFilename(file.name);
    this.file = file.name;


    if (this.fileType != 'xml') {
      alert("Wrong XML");
      return;
    }
    const reader = new FileReader();
    reader.onload = (e: any) => {
      let xml = e.target.result;
      this.inputXml = xml;
      let result1 = converter.xml2json(xml, { compact: true, spaces: 2 });

      const JSONData = JSON.parse(result1);
      this.xml = JSONData;
      this.list = [];
      let list: any = [];
      list = Array.isArray(JSONData.Patients.Patient) ? JSONData.Patients.Patient : [];
      let index: number = 0;
      if (list) {
        for (let i of list) {
          i.class_name = 'info';
          if (index % 2 == 0) {
            i.class_name = 'success';
          }
          let t: any = {
            class_name: i.class_name ? i.class_name : '',
            FirstName: i.FirstName._text ? i.FirstName._text : '',
            LastName: i.LastName._text ? i.LastName._text : '',
            PoliclinicCode: i.PoliclinicCode._text ? i.PoliclinicCode._text : '',
            DoctorID: i.DoctorID._text ? i.DoctorID._text : '',
          }
          this.list.push(t)
          index++;
        }
      }



    }

    reader.readAsText(event.target.files[0])
  }
  fileType: any = ''
  fileName: any = '';
  file: any = '';
}
