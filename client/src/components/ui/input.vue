<template>
  <section>
    <div class="input-component login-details">
      <label :for="`input-${label}`">{{ label }}</label>
     
      <component 
        :is="getType(type)"
        :type="type" 
        :name="`input-${label}`"
        :id="`input-${label}`" 
        :placeholder="placeholder"
        @input="onInput($event.target.value)"
        :maxlength="limit"
        :class="{error: !isValid}"
        @blur="validate($event.target.value)"/>
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

<style lang="scss" scoped>
.error {
  color: red;
}
</style>

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

  @Prop({
    default: () => () => true,
  })
  CustomValidator!: (value: string) => boolean;

  private getType = 
    (type: string) => (type === `textarea` ? `textarea` : `input`)

  private length = 0;

  private isValid = true;

  // Do I need this?
  // private convertToProperType(value: string) {
  //   switch (this.type) {
  //     case "text":
  //     case "textarea":
  //       return value;
  //     case "number":
  //       return Number(value);
  //     case "date":
  //       return new Date(value);
  //   }
  // }

  private validate(value: string) {
    // const isMinLengthValid = this.checkMinLength(value); // TODO: Add in future if needed
    const isCustomValid = this.CustomValidator(value);
    this.isValid = isCustomValid;

    this.$emit("onValidate", isCustomValid);
  }

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
