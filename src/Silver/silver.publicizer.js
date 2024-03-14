import {createPublicizer} from "publicizer";

export const publicizer = createPublicizer("Silver");

publicizer.createAssembly("tModLoader").publicizeAll();