export interface Registration {
  UserRegistration: {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    gender: string;
    dateOfBirth: Date;
  };
  Address: {
    line1: string;
    city: string;
    country: string;
  };
}
