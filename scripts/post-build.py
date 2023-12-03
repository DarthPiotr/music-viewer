import os
import sys
import glob
import shutil

# Config which files should be copied to the output directory
item_list = [
        {
            "folder": "MusicViewer.DAOMock", 
            "files": [
                "MusicViewer.DAOMock.dll"
            ]
        },
        {
            "folder": "MusicViewer.DAOSQL", 
            "files": [
                "MusicViewer.DAOSQL.dll",
                "appsettings.json",
                "assignments.db"
#                 "runtimes\\*",
#                 "*.dll"
            ]
        }
    ]

def copy_files_and_directories(source_path, destination_path, wildcard_paths):
    for wildcard_path in wildcard_paths:
        # Get a list of paths matching the wildcard in the source directory
        joined_path = os.path.join(source_path, wildcard_path)
        matching_paths = glob.glob(joined_path)
        # print(f"[INFO] {joined_path}")
        # print(f"[INFO] {matching_paths}")

        for path in matching_paths:
            # Get the relative path from the source directory
            relative_path = os.path.relpath(path, source_path)

            try:
                # Determine if the path is a file or directory
                if os.path.isfile(path):
                    # If it's a file, check if it exists in the destination directory
                    dest_file_path = os.path.join(destination_path, relative_path)
                    if not os.path.exists(dest_file_path):
                        # Copy the file to the destination directory
                        shutil.copy2(path, dest_file_path)
                        print(f"[OK] Copied file: {relative_path}")
                    else:
                        print(f"[!] File already exists: {relative_path}")
                elif os.path.isdir(path):
                    # If it's a directory, create it in the destination directory if not present
                    dest_dir_path = os.path.join(destination_path, relative_path)
                    if not os.path.exists(dest_dir_path):
                        os.makedirs(dest_dir_path)
                        print(f"[OK] Created directory: {relative_path}")

                    # Recursively traverse the directory using the same algorithm
                    copy_files_and_directories(path, dest_dir_path, ['*'])
            except Exception as e:
                print(f"[!!!] Error processing {relative_path}: {str(e)}")


def process_item(item, solution_dir, out_dir):
    folder, files = item["folder"], item["files"]
    source_path = os.path.join(solution_dir, folder, "bin", "Debug", "net7.0")
    copy_files_and_directories(source_path, out_dir, files)
    return True

if __name__ == "__main__":
    ### For debug
    # for i, arg in enumerate(sys.argv):
    #         print(f"i: '{arg}'")

    if len(sys.argv) != 3:
        print(f"Usage: python {sys.argv[0]} <solution_dir> <out_dir>")
        
        sys.exit(1)

    solution_dir = sys.argv[1]
    out_dir = sys.argv[2]

    print("\n=== Post Build Script ===")
    result = "Succeeded"

    for item in item_list:
        if not process_item(item, solution_dir, out_dir):
            result = "Failed"
    
    print(f"=== Post Build Script: {result} ===\n")