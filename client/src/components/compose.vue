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
      <div>
        <textarea
          class="input"
          name="body"
          form="post"
          placeholder="Play sound of bird"
        />
      </div>

      <section class="buttons">
        <div>Icons</div>
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
  // @apply p-4;

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
import { Component, Vue } from "vue-property-decorator";
import { mapGetters } from "vuex";
import { User } from "@/models";

@Component({
  computed: {
    ...mapGetters(["user"]),
  },
})
export default class Compose extends Vue {
  user!: User;
}
</script>
