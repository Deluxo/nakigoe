<template>
  <form class="flex" id="post">
    <!-- Picture -->
    <section class="w-3/12">
      <img :src="`/p/${user.ProfilePic}`" alt="Username" class="object-scale-down" />
    </section>

    <!-- Post -->
    <section class="w-9/12 flex flex-col">
      <section>
        <textarea
          class="resize-none w-full"
          name="body"
          form="post"
          placeholder="Play sound of bird"
        />
      </section>
      <section class="flex justify-between">
        <div class="self-center">Icons</div>
        <div class="self-center">
          <button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">鳴き声する</button>
        </div>
      </section>
    </section>
  </form>
</template>

<style lang="scss" scoped>
img {
  width: 70px;
  height: 70px;
  border-radius: 20px;
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
