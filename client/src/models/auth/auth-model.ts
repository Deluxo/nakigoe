/**
 * What gets returned from the server on login
 */
export type AuthModel = {
  UserName: string;
  BirthDate: Date;
  DisplayName: string;
  Bio: string;
  Token: string;
  ProfilePic: string;
}
