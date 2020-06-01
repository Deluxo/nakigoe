<template>
  <section>
    <div class="input-component login-details">
      <label :for="`input-${label}`">{{ label }}</label>
      <input 
        :type="type" 
        :name="`input-${label}`"
        :id="`input-${label}`" 
        placeholder="Your username"
        @input="onInput($event.target.value)"
        :maxlength="limit">
    </div>

    <div class="flex justify-end">
      <span 
        v-if="limit > 0"
        class="text-xs">
        {{ length }} / {{ limit }}
    </span>
    </div>
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
  type!: string;

  @Prop({ default: 0 })
  limit!: number;

  private length = 0;

  private onInput(value: string) {
    if (this.limit > 0)
      if (value.length > this.limit) {
        return;
      }

    this.length = value.length;
    this.$emit("input", value);
  }
}
</script>
