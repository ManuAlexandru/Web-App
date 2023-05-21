import { ProgramModel } from './programModel';

export class TrainerModel {
  idTrainerPage: String;
  userId: String;
  firstName: String;
  lastName: String;
  description: String;
  city: String;
  country: String;
  address: String;
  gyms: Array<string>;
  photos: Array<string>;
  profilePhoto: File;
  program: ProgramModel;
}
