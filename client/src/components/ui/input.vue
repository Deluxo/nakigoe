<template>
  <section>
    <div class="input-component login-details">
      <label :for="`input-${label}`">{{ label }}</label>
     
      <Textarea 
        v-if="type == `textarea`"
        :name="`input-${label}`"
        :id="`input-${label}`" 
        :placeholder="placeholder"
        @input="onInput($event.target.value)"
        :maxlength="limit"
        :class="{error: !isValid}"/>
      <input 
        v-else
        :type="type" 
        :name="`input-${label}`"
        :id="`input-${label}`" 
        :placeholder="placeholder"
        @input="onInput($event.target.value)"
        :maxlength="limit"
        :class="{error: !isValid}" />
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

  @Prop({ default: -1 })
  limit!: number;

  @Prop()
  placeholder!: string;

  @Prop()
  CustomValidator!: (value: string) => boolean;

  private length = 0;

  private isValid = true;

  private onInput(value: string) {
    if (this.limit > 0)
      if (value.length > this.limit) {
        return;
      }

    this.isValid = this.CustomValidator(value);
    if (!this.isValid) {
      return;
    }

    this.length = value.length;
    this.$emit("input", value);
  }
}
</script>
