export type LoginModel = {
  UserName: string;
  Password: string;
}

export const CreateEmptyLoginModel = 
  (): LoginModel => ({
    UserName: "",
    Password: "",
  });
