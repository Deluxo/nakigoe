export enum MediaType {
  Gif = "gif", 
  Image = "image",
  Video = "video"
}

export type PostingModel = {
  Body: string;
  Media: Array<File>;
  // Because the app needs to react differently depending on the type of media
  MediaType: MediaType | null;
}

export const createEmpty =
  (): PostingModel => ({
    Body: "",
    Media: [],
    MediaType: null,
  });
