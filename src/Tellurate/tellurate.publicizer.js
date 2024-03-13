import {createPublicizer} from "publicizer";

export const publicizer = createPublicizer("Tellurate");

publicizer.createAssembly("tModLoader").publicizeAll();