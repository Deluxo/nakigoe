import { User } from "@/models/user";

export class StorageService {
  static get Token(): string | null {
    return localStorage.getItem("Token");
  }

  static set Token(value: string | null) {
    if (!value) return;
    localStorage.setItem("Token", value);
  }

  static get IsAuthenticated() {
    console.log(this.Token);
    return !!this.Token;
  }

  static get User() {
    const json = localStorage.getItem("User");
    if (!json)
      return null;

    const user = JSON.parse(json) as User;
    return user;
  }

  static set User(value: User | null) {
    const json = JSON.stringify(value);
    localStorage.setItem("User", json);
  }

  static Store(user: User, token: string) {
    this.User = user;
    this.Token = token;
  }
}
