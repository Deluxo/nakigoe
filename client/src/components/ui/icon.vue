<template>
  <div class="i-container">
    <img 
      class="i-image"
      :src="`/icons/${Icon}.svg`" 
      :alt="Icon">
    <p 
      v-if="text"
      class="i-text">
      {{ text }}
    </p>
  </div>
</template>

<style lang="scss" scoped>
.i-container {
  @apply p-2;
  @apply rounded-full;

  &:hover {
    @apply bg-gray-500;
  }

  .i-image {
    @apply inline-block;
    @apply align-middle;
    height: 1rem;
  }

  .i-text {
    @apply inline-block;
    @apply align-middle;

    @apply ml-2;
  }
}
</style>

<script lang="ts">
// @ is an alias to /src
import { Component, Vue, Prop } from "vue-property-decorator";

const validIcons = [
  "add",
  "addcam",
  "bulb", 
  "message",
  "photo",
  "user",
];

@Component
export default class Icon extends Vue {
  @Prop({
    required: true,
    type: String,
    validator: icon => validIcons.findIndex(validIcon => icon === validIcon) !== -1,
  })
  Icon!: string;

  @Prop({
    type: String,
  })
  text!: string;
}
</script>
