export interface GenericResponse {
   // errorMessage: string;
    message: string;
    statusCode:number;
    isAuthSuccessful: boolean;
    token: string;
  }