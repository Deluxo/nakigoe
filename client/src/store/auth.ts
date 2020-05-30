import {
  Module, VuexModule, Mutation, Action, 
} from "vuex-module-decorators";
import { apiService } from "@/services/api-service";

type User = Record<string, string>;
type RegisterModel = string;

@Module
export default class Auth extends VuexModule {
  private Token: string | null = null;
  private User: User | null = null;
  private IsAuthenticated = false;

  get token(): string | null {
    return this.Token;
  }

  get user(): User | null {
    return this.User;
  }

  get isAuthenticated(): boolean {
    return this.IsAuthenticated;
  }

  @Mutation
  Authenticate(token: string, user: User) {
    this.IsAuthenticated = true;
    this.Token = token;
    this.User = user;
  }

  @Action
  async Register(user: RegisterModel) {
    const auth = await apiService.Post("/register", user);
    const data = await auth.json();
    console.log(data);
  }
}
