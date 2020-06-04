<template>
  <section class="grid grid-cols-4 gap-3">
    <DirectionButton 
      v-if="!hideBackwards"
      class="direction-button col-start-3"
      @click="switchForm"
      direction="backwards"/>

    <DirectionButton 
      v-if="!hideForwards"
      class="direction-button col-start-4"
      @click="switchForm"
      direction="forwards"/>

    <!-- I think when you can't go to the next you should be able to  -->
    <DirectionButton 
      v-if="hideForwards" 
      class="direction-button col-start-4"
      @click="finish"
      direction="finish"/>
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

  finish() {
    this.$emit("finish");
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
