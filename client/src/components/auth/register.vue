<template>
  <form>
    <h2 class="text-xl font-bold">Create your account</h2>
    <section class="input login-details">
      <label for="user-name">Username</label>
      <input 
        type="text" 
        name="user-name"
        id="user-name" 
        placeholder="Your username" 
        v-model="model.UserName">
    </section>

    <button 
      class="button button-blue"
      @click="printModel"
      type="button">
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
    if (!this.model)
      return;

    console.log(JSON.stringify(this.model));
  }
}
</script>
