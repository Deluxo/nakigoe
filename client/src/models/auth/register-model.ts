export type RegisterModel = {
  UserName: string;
  Password: string; 
  BirthDate: Date;
  DisplayName: string;
  Bio: string;
}

export const createEmptyModel = 
  (): RegisterModel => ({
    UserName: "",
    Password: "",
    BirthDate: new Date(Date.now()),
    DisplayName: "",
    Bio: "",
  });
