<template>
  <section class="home">
    <!-- The write a new post thing -->
    <Compose />

    <!-- Posts should then go here -->
  </section>
</template>

<script>
// @ is an alias to /src
import { Component, Vue } from "vue-property-decorator";
import Compose from "@/components/compose.vue";

@Component({
  components: {
    Compose,
  },
})
export default class Home extends Vue {}
</script>
