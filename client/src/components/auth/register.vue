<template>
  <form>
    <h2 class="text-xl font-bold">Create your account</h2>

    <section class="user-details" v-show="page == 0">
      <h3 class="font-bold">First we need some login details</h3>

      <InputComponent
        label="Username"
        placeholder="Your login name"
        v-model="model.UserName"
        limit="50"
        :custom-validator="validateUserName"
        @onValidate="v => isUsernameValid = v"
      />

      <InputComponent
        label="Password"
        placeholder="Password"
        v-model="model.Password"
        type="password"
      />
    </section>

    <section class="personal-details" v-show="page == 1">
      <h3 class="font-bold">Now for some information about you</h3>

      <InputComponent label="Name" placeholder="Display name" v-model="model.Display" limit="25" />

      <InputComponent
        label="Birthdate"
        placeholder="Birthdate"
        v-model="model.BirthDate"
        type="date"
      />
    </section>

    <section class="bio" v-show="page == 2">
      <h3>And finally a good profile picture and a description of yourself</h3>


      <ImageInput 
        message="Picture"
        class="picture"/>

      <InputComponent
        label="Bio"
        placeholder="Say something nice about yourself"
        type="textarea"
        v-model="model.Bio"
        limit="140"
      />
    </section>

    <section>
      <DirectionButtonPair
        @click="switchForm"
        @finish="finish"
        :hide-backwards="page == 0"
        :hide-forwards="page == pageCount - 1"
      />
    </section>
  </form>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { RegisterModel, createEmptyModel } from "@/models";
import InputComponent from "@/components/ui/input.vue";
import ImageInput from "@/components/ui/image-input.vue";
import DirectionButtonPair from "@/components/auth/direction-button-pair.vue";
import { mapActions } from "vuex";

// enum Page {
//   UserDetails,
//   PersonalDetails,
//   Bio
// }

@Component({
  components: {
    InputComponent,
    DirectionButtonPair,
    ImageInput,
  },
  methods: {
    ...mapActions(["Register"]),
  },
})
export default class Register extends Vue {
  Register!: (user: RegisterModel) => void;

  private isUsernameValid = true;

  private model: RegisterModel | null = null;

  private page = 0;
  private pageCount = 3;

  pictureUploaded(image: HTMLImageElement) {
    console.log(image);
  }

  created() {
    this.model = createEmptyModel();
  }

  switchForm(direction: number) {
    // const lastPage = this.page === this.pageCount - 1;
    // if (lastPage) // This is probably not needed
    //   return;

    const isModelValid = this.validateModel();
    if (!isModelValid)
      return;

    this.page =
      (this.page + direction + this.pageCount) % this.pageCount; // Mod with pagecount to prevent over and underflow
  }

  validateModel(): boolean {
    // switch (this.page) {
    //   case Page.UserDetails:
    //     return this.validateUserDetails();
    //   case Page.PersonalDetails:
    //     return this.validateModel();
    //   case Page.Bio:
    //     return this.validateBio();
    //   default:
    //     return false;
    // }
    return true;
  }

  validateUserName(userName: string) {
    // if (userName[0] === "i")
    //   return true;

    // return false;
    return true;
  }

  validateUserDetails() {
    console.log(this.isUsernameValid);
    return false;
  }

  validatePersonalDetails() {
    return false;
  }

  validateBio() {
    return false;
  }

  finish() {
    if (!this.model)
      return;

    this.Register(this.model);
  }
}
</script>
