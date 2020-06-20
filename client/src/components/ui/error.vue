<template>
  <section class="ui-error">
    <p>{{ message }}</p>
  </section>
</template>

<style lang="scss" scoped>
.ui-error {
  @apply bg-red-500;
  @apply text-white;
  @apply w-full;
  @apply p-4;
  @apply font-bold;
  @apply rounded;
}
</style>

<script lang="ts">
import { Component, Vue, Prop } from "vue-property-decorator";

@Component
export default class Error extends Vue {
  @Prop()
  message!: string;
}
</script>
