import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { GenericResponse } from 'src/app/module/interfaces/GenericResponse';
import { PhotoModel } from 'src/app/module/models/photoModel';
import { PhotoToSaveModel } from 'src/app/module/models/photoToSaveModel';
import { OwnerGymServices } from 'src/app/module/services/ownerGymServices/ownerServices';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';
import { DeletePhotoModel } from 'src/app/module/models/deletePhotoModel';
@Component({
  selector: 'app-owner-page-images',
  templateUrl: './owner-page-images.component.html',
  styleUrls: ['./owner-page-images.component.css'],
})
export class OwnerPageImagesComponent implements OnInit {
  constructor(
    private _ownerService: OwnerGymServices,
    private _authService: AuthUser,
    private fb: FormBuilder
  ) {}
  activeButton: boolean = false;
  duplicateName: string[] = [''];
  photArr: PhotoModel[];
  photoToBeDeleted: DeletePhotoModel;
  myFiles: string[] = [];
  imageGroup: FormGroup;
  statusClass: string = 'default';
  ngOnInit(): void {
    this._ownerService
      .getPhotosRoutes(this._authService.getId())
      .subscribe((data) => {
        this.photArr = data;
      });
    this.imageGroup = this.fb.group({
      file: ['', [Validators.required]],
    });
    this.photoToBeDeleted = {
      id: '',
      photoDetails: new Array().fill({ route: '', fileName: '' }),
    };
  }

  onFileChange(event) {
    this.myFiles = [];
    this.duplicateName = [''];
    this.activeButton = true;

    for (var i = 0; i < event.target.files.length; i++) {
      this.myFiles.push(event.target.files[i]);
    }
  }
  submit() {
    const formData = new FormData();
    for (var i = 0; i < this.myFiles.length; i++) {
      formData.append('File', this.myFiles[i]);
    }
    console.log(formData.get('File'));
    this._ownerService
      .addPagePhotos(formData, this._authService.getId())
      .subscribe((response: GenericResponse) => {
        console.log(response.message);
        this.activeButton = false;
        this.ngOnInit();
      });
  }

  SubmitForDelete() {
    this.photoToBeDeleted.id = this._authService.getId();
    this._ownerService
      .deletePagePhotos(this.photoToBeDeleted)
      .subscribe((response: GenericResponse) => {
        console.log(response.message);
        this.RemoveFromOriginArr(this.photArr, this.photoToBeDeleted);
      });
  }
  
  onClickPage(photo: PhotoModel) {
    if (photo.isSelected == false || photo.isSelected == null) {
      photo.isSelected = true;
      this.photoToBeDeleted.photoDetails.push(photo);
    } else {
      photo.isSelected = false;
      console.log(photo);
      this.photoToBeDeleted.photoDetails = this.ArrayRemove(
        this.photoToBeDeleted.photoDetails,
        photo.fileName
      );
    }
  }

  private ArrayRemove(arr: PhotoModel[], value) {
    return arr.filter(function (elem) {
      return elem.fileName != value;
    });
  }

  private RemoveFromOriginArr(
    arr: PhotoModel[],
    removedPhotos: DeletePhotoModel
  ) {
    for (let i = 0; i < removedPhotos.photoDetails.length; i++) {
      const index = arr.indexOf(removedPhotos.photoDetails[i]);
      if (index !== -1) {
        arr.splice(index, 1);
      }
    }
  }
}
