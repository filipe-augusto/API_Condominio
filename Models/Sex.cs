﻿namespace API_Condominio.Models;

public class Sex
{
    public short Id { get; set; }
    public string Name { get; set; }
    public List<Resident> Residents { get; set; }


}

