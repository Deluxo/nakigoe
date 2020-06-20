import {
  Module, VuexModule, Mutation, Action, 
} from "vuex-module-decorators";
import { apiService } from "@/services/api-service";
import { RegisterModel, AuthModel, User } from "@/models";
import { LoginModel } from "@/models/auth/login-model";
import { LocalStorageService } from "@/services/local-storage-service";

@Module
export default class Auth extends VuexModule {
  private Token = LocalStorageService.Token;
  private User = LocalStorageService.User;
  private IsAuthenticated = LocalStorageService.IsAuthenticated;

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
    
    LocalStorageService.Store(this.User, this.Token);
  }

  @Action({ rawError: true })
  async Login(user: LoginModel) {
    const auth = await apiService.Post("/login", user);

    if (auth.status !== 200) {
      return auth.text();
    }

    const data = await auth.json() as AuthModel;
    
    this.context.commit("Authenticate", data);
    
    return null;
  }
  @Action({ rawError: true })
  async Register(user: RegisterModel) {
    const auth = await apiService.Post("/register", user);
    
    if (auth.status !== 200) {
      return auth.text();
    }
    
    const data = await auth.json() as AuthModel;

    this.context.commit("Authenticate", data);

    return null;
  }
}
