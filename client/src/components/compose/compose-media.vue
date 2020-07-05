<template>
  <section>
    <input 
      v-bind="media"
      ref="image-input"
      type="file" 
      name="files" 
      class="hidden"
      @change="imageSelected"
      multiple>
  </section>
</template>

<script lang="ts">
import {
 Component, Prop, Vue, Ref, 
} from "vue-property-decorator";

@Component
export default class ComposeMedia extends Vue {
  private media!: File[];
  private validMediaTypes = /(video|image)\//;

  @Ref("image-input")
  imageInput!: HTMLInputElement;

  created() {
    this.media = [];
  }

  addImages() {
    this.imageInput.click();
  }

  imageSelected() {
    const { files } = this.imageInput;
    if (files === null) return; 

    const images = [...files];

    if (files.length > 4) {
      console.log("Too many files");
    }

    // Check for mimetypes that are not image or video
    const mimeTypes = this.getMimeTypes(images);
    const invalidMimeTypeExists = this.containsInvalidMimetypes(mimeTypes);
    if (invalidMimeTypeExists) {
      console.log("User needs to upload only images or video");
    }


    const validTypes = this.uniqueTypes(images);
    
    if (validTypes.size > 1)
      console.log("Image and video uploaded");


    console.log("やった");
    }

    getMimeTypes(images: File[]) {
      return images.map(image => image.type);
    }

    containsInvalidMimetypes(mimeTypes: string[]) {
      const notValidMimeType = 
        (mimeType: string) => !this.validMediaTypes.test(mimeType);
      
      const invalidMimeType = mimeTypes.find(notValidMimeType);
      
      return !!invalidMimeType;
    }

    uniqueTypes(images: File[]) {
      const validMediaTypes = /(video|image)\//;
      const fileTypes = images.map(file => file.type.match(validMediaTypes)![0]);
      const uniqueTypes = new Set(fileTypes); 
      return uniqueTypes;
    }
}
</script>
