<template>
  <form>
    <!-- COMPONIZZLE THIS SHIZZLE -->
    <section 
      class="error bg-red-500 text-white w-full p-4 font-bold rounded"
      v-if="error">
      {{ error }}
    </section>

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
  private error: string | null = null;

  Login!: (user: LoginModel) => Promise<string | null>;

  created() {
    this.model = CreateEmptyLoginModel();
  }

  async loginButtonClick() {
    this.error = await this.Login(this.model);
  }
}
</script>
