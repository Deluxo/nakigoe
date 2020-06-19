import {
  Module, VuexModule, Mutation, Action, 
} from "vuex-module-decorators";
import { apiService } from "@/services/api-service";
import { RegisterModel, AuthModel, User } from "@/models";
import { LoginModel } from "@/models/auth/login-model";


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
  Authenticate(auth: AuthModel) {
    this.IsAuthenticated = true;
    this.Token = auth.Token;
    this.User = auth as User;
    console.log(auth);
  }

  @Action({ rawError: true })
  async Login(user: LoginModel) {
    const auth = await apiService.Post("/login", user);

    if (auth.status !== 200) {
      return auth.body;
    }

    const data = await auth.json() as AuthModel;
    console.log(data);
    this.context.commit("Authenticate", data);
    
    return "Signed in";
  }
  @Action({ rawError: true })
  async Register(user: RegisterModel) {
    const auth = await apiService.Post("/register", user);
    
    if (auth.status !== 200) {
      console.log(await auth.text());
      return auth.body;
    }
    
    const data = await auth.json() as AuthModel;

    this.context.commit("Authenticate", data);

    return "Signed in";
  }
}
