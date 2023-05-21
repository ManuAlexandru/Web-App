import { PhotoModel } from './photoModel';

export class GymModel {
  idPage: string;
  userId: string;
  gymName: string;
  description: string;
  country: string;
  city: string;
  addres: string;
  price: string;
  typeOfMoney: string;
  typeOfGym: string;
  phoneNumber: number;
  isCreditCardPaymentPossible: boolean;
  hasSevenCard: boolean;
  photos: PhotoModel[];
}
