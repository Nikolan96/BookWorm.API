export interface User {
  id?: any;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  gender: string;
  dateOfBirth: Date;
  addressId: any;
  roleId: any;
  role: {
    id: string;
    name: string;
  }
  currentLevel: any;
  nextLevel: any;
  experience: any;
}
