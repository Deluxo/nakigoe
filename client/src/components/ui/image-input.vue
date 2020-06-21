<template>
  <section class="ii-box" @click="upload">
    <img 
      ref="image" 
      v-if="image"
      :src="image">

    <input type="file" class="ii-hidden" ref="ii-input" @change="imageChange">
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

  private image: string | null = null;

  async imageChange() {
    const { files } = this.input;

    if (!files) return;

    const file = files[0];
    await this.displayImage(file);
    
    this.$emit("image-change", file); 
  }

  displayImage(file: File) {
    return new Promise((resolve, reject) => {
      const fileReader = new FileReader();
      fileReader.readAsDataURL(file);

      // Add it to the image
      fileReader.onload = () => {
        const image = fileReader.result as string; 
        this.image = image; 
        resolve(true);
      };

      // Just in case
      fileReader.onerror = 
        error => {
          reject(error);
        };
    });
  }

  upload() {
    console.log("Upload");
    this.input.click();
  }
}
</script>
