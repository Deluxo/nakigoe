<template>
  <section 
    class="modal"
    v-if="isShown">

    <section class="overlay" @click="toggleShown">
      <!-- This tag has intentionally been left blank -->
    </section>

    <section class="modal-container">
      <section>
        <slot />
      </section>
    </section>
  </section>
</template>

<style lang="scss" scoped>
@mixin modalify {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
}

.modal {
  @include modalify;

  @apply flex;
  @apply items-center;
  @apply justify-center;
}

.overlay {
  @include modalify;

  @apply bg-gray-900;
  @apply opacity-50;
}

.modal-container {
  @apply bg-white;
  @apply z-50;
  @apply p-2;
  @apply rounded-lg;
}
</style>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

@Component
export default class Modal extends Vue {
  private isShown = false;

  toggleShown() {
    this.isShown = !this.isShown;
  }
}
</script>
