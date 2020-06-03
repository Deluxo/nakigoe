<template>
  <button
    @click="emit"
    type="button">{{ directions[direction].name }}</button>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";

interface Direction {
  name: string;
  number: number;
}

// Temp permanent hack to lookup directions
interface Directions {
  [key: string]: Direction;
}

@Component
export default class DirectionButton extends Vue {
  @Prop()
  direction!: string;

  private directions: Directions = { 
    forwards: { 
      name: "Next",
      number: 1,
    },
    backwards: {
      name: "Previous",
      number: -1,
    },
    finish: {
      name: "Finish",
      number: 2,
    },
  };

  private validDirections = ["forwards", "backwards"];
  
  created() {
    const isInvalidDirecion = 
      this.validDirections.findIndex(validDirecion => validDirecion === this.direction) === -1;

    if (isInvalidDirecion) {
      throw Error("The direction needs to be either forwards or backwards");
    }  
  }

  emit() {
      if (!this.direction) return; //

    const direction = this.directions[this.direction].number;
    this.$emit("click", direction);
  }
}
</script>
