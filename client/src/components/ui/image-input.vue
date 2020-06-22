<template>
  <section 
    class="ii-box" 
    @click="upload"
    @drop="imageDropped"
    @dragover="imageDragged">
    <img 
      ref="image" 
      v-if="image"
      :src="image">

    <input 
      type="file" 
      class="ii-hidden" 
      ref="ii-input" 
      @change="imageChange">
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

  // Prevents the browser default
  private imageDragged(event: DragEvent) {
    event.preventDefault();
  }

  private imageDropped(event: DragEvent) {
    event.preventDefault();
    const data = event.dataTransfer as DataTransfer;
    const file = data.files[0];
    this.handleFile(file);
  }

  async handleFile(file: File) {
    await this.displayImage(file);
    
    this.$emit("image-change", file); 
  }

  async imageChange() {
    const { files } = this.input;

    if (!files) return;

    const file = files[0];
    this.handleFile(file);
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
