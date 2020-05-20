<template>
  <form class="flex" id="post">
    <!-- Picture -->
    <section>
      <img
        src="http://placekitten.com/200/200"
        alt="Username"
        class="object-scale-down"
      />
    </section>

    <!-- Post -->
    <section class="flex flex-col">
      <section>
        <textarea
          type="text"
          name="body"
          form="post"
          placeholder="Play sound of bird"
        />
      </section>
      <section class="flex justify-between">
        <div class="self-center">Icons</div>
        <div class="self-center">
          <button
            class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded"
          >
            鳴き声する
          </button>
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

<script>
// @ is an alias to /src
import { Component, Vue } from "vue-property-decorator";

@Component
export default class Compose extends Vue {}
</script>
