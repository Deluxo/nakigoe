<template>
  <section>
    <DirectionButton 
      v-if="!hideBackwards"
      class="direction-button"
      @click="switchForm"
      direction="backwards"/>

    <DirectionButton 
      v-if="!hideForwards"
      class="direction-button"
      @click="switchForm"
      direction="forwards"/>
  </section>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import DirectionButton from "@/components/ui/direction-button.vue";

@Component({
  components: {
    DirectionButton,
  },
})
export default class DirectionButtonPair extends Vue {
  @Prop({ default: false })
  hideForwards!: boolean;

  @Prop({ default: false })
  hideBackwards!: boolean;

  switchForm(direction: number) {
    this.$emit("click", direction);
  }
}
</script>

<style lang="scss">
@import "@/styles/components/buttons";

.direction-button {
  @apply button;
  @apply button-blue;
  @apply button-small;
}
</style>
