﻿using System;
using System.Collections.Generic;

namespace robot_controller_api.Models;

public partial class RobotCommand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsMoveCommand { get; set; }

    public DateTime Createddate { get; set; }

    public DateTime Modifieddate { get; set; }
}
