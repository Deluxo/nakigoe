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
  </form>
</template>

<style lang="scss" scoped>
.input {
  margin-bottom:10px;
}
</style>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import InputComponent from "@/components/ui/input.vue";
import { LoginModel, CreateEmptyLoginModel } from "@/models/auth/login-model";

@Component({
  components: {
    InputComponent,
  },
})
export default class Login extends Vue {
  private model!: LoginModel;

  created() {
    this.model = CreateEmptyLoginModel();
  }
}
</script>
