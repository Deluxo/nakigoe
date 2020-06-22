<template>
  <section 
    class="ii-box" 
    @click="upload"
    @drop="imageDropped"
    @dragover="imageDragged">

    <section class="ii-preview">
      <img 
        class="ii-image"
        ref="image" 
        v-if="image"
        :src="image">
    </section>

    <input 
      type="file" 
      class="ii-hidden" 
      ref="ii-input" 
      @change="imageChange">
  </section>
</template>

<style lang="scss" scoped>
.ii-box {
  width: 400px;
  height: 400px;

  @apply border-8;
  @apply border-dashed;
}

.ii-hidden {
  display: none;
}

.ii-preview {
  height: 100%;

  .ii-image {
    margin: 0px auto;
    width: auto;
    height: 100%;
  }
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
    console.log(file);
    this.handleFile(file);
  }

  private async handleFile(file: File) {
    await this.displayImage(file);
    
    this.$emit("image-change", file); 
  }

  private async imageChange() {
    const { files } = this.input;

    if (!files) return;

    const file = files[0];
    this.handleFile(file);
  }

  private displayImage(file: File) {
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

  private upload() {
    console.log("Upload");
    this.input.click();
  }
}
</script>
