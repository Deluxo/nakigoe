<template>
  <form>
    <h2 class="text-xl font-bold">Create your account</h2>
    <section class="login-details">
      <input type="text" name="user-name" placeholder="Your username" v-model="model.UserName">
    </section>

    <button class="button button-blue" @click="printModel">
      Check model
    </button>
  </form>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { RegisterModel, createEmptyModel } from "@/models";

@Component
export default class Register extends Vue {
  private model: RegisterModel | null = null;

  created() {
    this.model = createEmptyModel();
  }

  printModel() {
    console.log(this.model);
  }
}
</script>
