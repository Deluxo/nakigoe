<template>
  <section 
    class="ii-box" 
    @click="upload"
    @drop="imageDropped"
    @dragover="imageDragged">

    <section 
      class="ii-preview"
      v-if="image">
      <img 
        class="ii-image"
        ref="image" 
        :src="image">
    </section>

    <section 
      v-else
      class="ii-message">
      <span>{{ message }}</span>
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
  @apply border-8;
  @apply border-dashed;
  display: flex;
  align-items: center;
  justify-content: center;
}

.ii-hidden {
  display: none;
}

.ii-preview {
  height: 100%;

  .ii-image {
    width: auto;
    height: 100%;
  }
}

.ii-message {
  @apply text-center;
  @apply h-24;
}
</style>

<script lang="ts">
import {
 Component, Vue, Ref, Prop, 
} from "vue-property-decorator";

@Component
export default class ImageInput extends Vue {
  @Prop({
    required: true, 
    type: String,
  })
  message!: string;

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
