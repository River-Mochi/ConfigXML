# <copyright file="CRLF2LF.py" company="River-Mochi">
# Copyright (c) 2026 River-Mochi. All rights reserved.
# Licensed under the MIT License. You may not use this file except in compliance with this License.
# See LICENSE file in the project root for full license information.
# This notice and the MIT License notice must be kept with
# all copies or substantial portions of this code.
# ================= </copyright> ======================

# File: Scripts/CRLF2LF.py
# Version: 0.2.1
# Purpose: Convert common tracked text files from CRLF/mixed endings to LF.

# Usage:
#   Run from the repo/mod root:
#     py -3 Scripts/CRLF2LF.py
#
# Behavior:
#   Scans the current working directory recursively.
#   Converts supported text files from CRLF/mixed endings to LF.
#   Removes UTF-8 BOM from supported text files.
#   Skips .git, .vs, bin, obj, and node_modules.

from pathlib import Path


UTF8_BOM = b"\xef\xbb\xbf"

TEXT_EXTENSIONS = {
    ".bash",
    ".cs",
    ".csproj",
    ".config",
    ".css",
    ".editorconfig",
    ".gitattributes",
    ".gitignore",
    ".html",
    ".js",
    ".jsx",
    ".json",
    ".jsonc",
    ".md",
    ".mjs",
    ".props",
    ".ps1",
    ".pubxml",
    ".py",
    ".resx",
    ".ruleset",
    ".sh",
    ".sln",
    ".slnx",
    ".targets",
    ".toml",
    ".txt",
    ".ts",
    ".tsx",
    ".xml",
    ".yaml",
    ".yml",
}

SKIP_PARTS = {
    ".git",
    ".vs",
    "bin",
    "obj",
    "node_modules",
}


for path in Path(".").rglob("*"):
    if not path.is_file():
        continue

    if any(part.lower() in SKIP_PARTS for part in path.parts):
        continue

    if path.suffix.lower() not in TEXT_EXTENSIONS and path.name not in TEXT_EXTENSIONS:
        continue

    original_data = path.read_bytes()
    data = original_data

    if data.startswith(UTF8_BOM):
        data = data[len(UTF8_BOM):]

    if b"\0" in data:
        continue

    new_data = data.replace(b"\r\n", b"\n").replace(b"\r", b"\n")
    if new_data != original_data:
        path.write_bytes(new_data)
        print(path)
