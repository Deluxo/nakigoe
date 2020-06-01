<template>
  <section class="input login-details">
    <label for="user-name">{{ label }}</label>
    <input 
      :type="type" 
      name="user-name"
      id="user-name" 
      placeholder="Your username"
      @input="onInput($event.target.value)">
  </section>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class Input extends Vue {
  @Prop()
  label!: string;

  @Prop()
  value!: string;

  @Prop({ default: "text" })
  type = "text"

  private onInput(value: string) {
    this.$emit("input", value);
  }
}
</script>
