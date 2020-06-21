<template>
  <section class="ii-box" @click="upload">
    <img ref="image">

    <input type="file" class="ii-hidden" ref="ii-input" @change="fileChange">
  </section>
</template>

<style lang="scss" scoped>
.ii-box {
  width: 800px;
  height: 400px;

  @apply border-8;
  @apply border-dashed;
}

.ii-hidden {
  display: none;
}
</style>

<script lang="ts">
import { Component, Vue, Ref } from "vue-property-decorator";

@Component
export default class ImageInput extends Vue {
  @Ref("ii-input")
  private input!: HTMLInputElement;

  @Ref("image")
  private image!: HTMLImageElement;

  fileChange() {
    const { files } = this.input;

    if (!files) return;

    const fileReader = new FileReader();
    fileReader.readAsDataURL(files[0]);
    fileReader.onload = () => { this.image.src = fileReader.result as string; };
  }

  upload() {
    console.log("Upload");
    this.input.click();
  }
}
</script>
