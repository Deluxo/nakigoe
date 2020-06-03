<template>
  <form>
    <h2 class="text-xl font-bold">Create your account</h2>
    
    <section 
      class="user-details"
      v-show="page == 0">
      <h3 class="font-bold">First we need some login details</h3>

      <InputComponent 
        label="Username"
        placeholder="Your login name"
        v-model="model.UserName"
        limit="50"/>

      <InputComponent 
        label="Password"
        placeholder="Password"
        v-model="model.Password"
        type="password"/>
    </section>

    <section 
      class="personal-details"
      v-show="page == 1">
      <h3 class="font-bold">Now for some information about you</h3>

      <InputComponent 
        label="Name"
        placeholder="Display name"
        v-model="model.Display"
        limit="25"/>

      <InputComponent 
        label="Birthdate"
        placeholder="Birthdate"
        v-model="model.BirthDate"
        type="date"/>
    </section>

    <section 
      class="bio"
      v-show="page == 2">
      <h3>And finally a short description of yourself</h3>
      <InputComponent 
        label="Bio"
        placeholder="Say something nice about yourself"
        type="textarea"
        v-model="model.Bio"
        limit="140"/>
    </section>
   
  <section>
      <DirectionButtonPair 
        @click="switchForm"
        :hide-backwards="page == 0"
        :hide-forwards="page == pageCount - 1"/>
  </section>

    <button 
      class="button button-blue"
      @click="printModel"
      type="button">
      Check model
    </button>
  </form>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import { RegisterModel, createEmptyModel } from "@/models";
import InputComponent from "@/components/ui/input.vue";
import DirectionButtonPair from "@/components/ui/direction-button-pair.vue";

@Component({
  components: {
    InputComponent,
    DirectionButtonPair,
  },
})
export default class Register extends Vue {
  private model: RegisterModel | null = null;

  private page = 0;
  private pageCount = 3;
  created() {
    this.model = createEmptyModel();
  }

  switchForm(direction: number) {
    this.page = 
      (this.page + direction + this.pageCount) % this.pageCount; // Mod with pagecount to prevent over and underflow
  }

  printModel() {
    if (!this.model)
      return;

    console.log(JSON.stringify(this.model));
  }
}
</script>
