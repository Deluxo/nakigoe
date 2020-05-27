import {
  Module, VuexModule, Mutation, Action,
} from "vuex-module-decorators";

type User = Object;

@Module
export default class Auth extends VuexModule {
  private Token: string | null = null;
  private User: User | null = null;
  
  get token(): string | null {
    return this.Token;
  }

  get user(): User | null {
    return this.User;
  }
}