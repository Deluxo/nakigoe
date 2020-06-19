<template>
  <form>
    <InputComponent 
      class="input"
      label="Username"
       v-model="model.UserName"
       placeholder="Username"
      />
    <InputComponent 
      class="input"
      type="password"
      label="Password"
      v-model="model.Password"
      placeholder="Password"/>

    <button 
      type="button"
      class="button button-blue w-full"
      @click="loginButtonClick">Log in</button>
  </form>
</template>

<style lang="scss" scoped>
.input {
  margin-bottom:10px;
}
</style>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import InputComponent from "@/components/ui/input.vue";
import { LoginModel, CreateEmptyLoginModel } from "@/models/auth/login-model";
import { mapActions } from "vuex";

@Component({
  components: {
    InputComponent,
  },
  methods: {
    ...mapActions(["Login"]),
  },
})
export default class Login extends Vue {
  private model!: LoginModel;
  Login!: (user: LoginModel) => Promise<void>;

  created() {
    this.model = CreateEmptyLoginModel();
  }

  loginButtonClick() {
    this.Login(this.model);
  }
}
</script>
