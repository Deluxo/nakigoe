<template>
  <section>
    <input v-bind="media" ref="image-input" type="file" name="files" class="hidden" @change="onSelected" multiple />
    <small v-if="errorMessage">{{ this.errorMessage }}</small>
  </section>
</template>

<script lang="ts">
  import { Component, Vue, Ref } from "vue-property-decorator";

  @Component
  export default class ComposeMedia extends Vue {
    private media!: File[];
    private validMediaTypes = /(video|image)\//;
    private errorMessage: string | null = null;

    @Ref("image-input")
    imageInput!: HTMLInputElement;

    created() {
      this.media = [];
    }

    addImages() {
      this.imageInput.click();
    }

    onSelected() {
      const files = this.imageInput.files === null ? [] : Array.from(this.imageInput.files);
      const videoFile = files.find((f: File) => f.type === "video");
      const imageFiles = files.filter((f: File) => f.type === "image");

      if (videoFile && imageFiles.length) {
        this.errorMessage = "only 1 video per upload allowed";
        return null;
      } else if (!videoFile && imageFiles.length > 4) {
        this.errorMessage = "only up to 4 images per upload allowed";
        return null;
      }

      this.errorMessage = null;
    }
  }
</script>
