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
        :class="{error: !isValid}"
        @blur="validate($event.target.value)"/>
      <input 
        v-else
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

  private length = 0;

  private isValid = true;

  private validate(value: string) {
    this.isValid = this.CustomValidator(value);
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
