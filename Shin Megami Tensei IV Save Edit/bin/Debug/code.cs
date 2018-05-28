            //plot
            offset = 0x98f8;
            for (byte i = 0; offset < 0x99e4; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }
            
            //quest/valuables
            //offset = 0x9958;
            //for (byte i = 0; i < 70; i++)
            //{
            //    data[offset] = (byte)(i + 1);
            //    data[offset + 1] = 0x00;

            //    offset += 2;
            //}

            //expendables
            offset = 0x99e4;
            for (byte i = 0; i < 60; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //swords
            offset = 0x9a5c;
            for (byte i = 0; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //firearms
            offset = 0x9b4c;
            for (byte i = 0; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }
            
            //helms
            offset = 0x9c3c;

            //data[offset] = 0x00;
            //data[offset + 1] = 0x00;

            //offset += 2;
            for (byte i = 1; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //data[offset] = 0x00;
            //data[offset + 1] = 0x00;

            //offset += 2;
            //for (short i = 1; i < 21; i++)
            //{
            //    data[offset] = 0x63;
            //    data[offset + 1] = 0x00;

            //    offset += 2;
            //}

            //upper body
            offset = 0x9d2c;
            for (byte i = 0; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //lower body
            offset = 0x9e1c;
            for (byte i = 0; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //accessories
            offset = 0x9f0c;
            for (byte i = 0; i < 120; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }

            //ammo
            offset = 0x9ffc;
            for (byte i = 0; i < 50; i++)
            {
                data[offset] = (byte)(i + 1);
                data[offset + 1] = 0x00;

                offset += 2;
            }
            
            //relics
            offset = 0xa060;
            byte[] id = new byte[2];
            for (short i = 0; i < 999; i++)
            {
                id = BitConverter.GetBytes((short)(i + 1));
                data[offset] = id[0];
                data[offset + 1] = id[1];

                offset += 2;
            }

            File.WriteAllBytes(filename, data);