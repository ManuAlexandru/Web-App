import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { MatChipInputEvent } from '@angular/material/chips';
import { TrainerService } from 'src/app/module/services/trainerService/trainerService';
import { AuthUser } from 'src/app/module/services/userServices/authUser.service';

@Component({
  selector: 'app-trainer-program',
  templateUrl: './trainer-program.component.html',
  styleUrls: ['./trainer-program.component.css'],
})
export class TrainerProgramComponent implements OnInit {
  programGroup: FormGroup;

  constructor(
    private _trainerService: TrainerService,
    private _authService: AuthUser,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.programGroup = this.fb.group({
      name: ['', [Validators.required]],
      price: ['', [Validators.required]],
      services: [[], [Validators.required]],
    });
  }

  get getName() {
    return this.programGroup.get('name');
  }
  get getPrice() {
    return this.programGroup.get('price');
  }
  get getServices() {
    return this.programGroup.get('services');
  }

  submit() {
    console.log(this.programGroup.value);
    // this._trainerService
    //   .addProgram(this.programGroup.value, this._authService.getId())
    //   .subscribe((data) => {
    //     console.log(data);
    //   });
  }
}
