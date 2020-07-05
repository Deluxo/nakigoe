<template>
  <form class="post-container" id="post">
    <!-- Picture -->
    <section class="profile-picture-container">
      <img 
        :src="`/p/${user.ProfilePic}`" 
        alt="Username" />
    </section>

    <!-- Post -->
    <section class="posting-container">
      <section class="input-container">
        <textarea
          v-bind="post.Body"
          class="input"
          name="body"
          form="post"
          placeholder="Play sound of bird"
        />
      </section>

      <section class="images">
        <Media ref="media-container"/>
      </section>

      <section class="buttons">
        <div class=icons>
          <Icon 
            icon="photo"
            @click="addImages"/>
        </div>
        <div>
          <button class="button button-blue">鳴き声する</button>
        </div>
      </section>
    </section>
  </form>
</template>

<style lang="scss" scoped>
.post-container {
  @apply flex;
  @apply p-2;
}

.profile-picture-container {
  @apply w-1/12;

  img {
    @apply w-16;
    @apply object-scale-down;
    border-radius: 20px;
  }
}

.input {
  @apply resize-none; 
  @apply w-full;
}

.posting-container {
  @apply w-9/12;
  @apply flex;
  @apply flex-col;
}

.buttons {
  @apply flex;
  @apply justify-between;

  div {
    @apply self-center;
  }
}
</style>

<script lang="ts">
// @ is an alias to /src
import { Component, Vue, Ref } from "vue-property-decorator";
import { mapGetters } from "vuex";
import { User } from "@/models";
import Icon from "@/components/ui/icon.vue";
import { PostingModel, createEmpty } from "@/models/post/PostingModel";
import Media from "@/components/compose/compose-media.vue";

@Component({
  components: {
    Icon,
    Media,
  },
  computed: {
    ...mapGetters(["user"]),
  },
})
export default class Compose extends Vue {
  user!: User;
  post!: PostingModel;

  @Ref("media-container")
  mediaContainer!: Media;

  created() {
    this.post = createEmpty();
  }

  addImages() {
    this.mediaContainer.addImages();
  }
}
</script>
